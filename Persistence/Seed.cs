using System.Text.RegularExpressions;
using Domain;

namespace Persistence;

public static class Seed
{
    public static async Task SeedData(DataContext context)
    {
        if (context.StudyFiles.Any()) return;
        
        var regex = new Regex(@"[0-9]");
        //local seeding for dev purposes
        var coursesDirs =Directory.EnumerateDirectories("Q:\\charity");

        foreach (var coursesDir in coursesDirs)
        {
            var coursesDirLength = coursesDir.Length;
            var match = regex.Match(coursesDir);
            var course = byte.Parse(regex.Match(coursesDir).Groups[0].Value);
            var subjectDirs = Directory.EnumerateDirectories(coursesDir);
            foreach (var subjectDir in subjectDirs)
            {
                var subjectDirLength = subjectDir.Length;
                foreach (var innerDir in Directory.EnumerateDirectories(subjectDir))
                {
                    await foreach (var studyFile in ReccursiveEnum(innerDir, course, subjectDir.Substring(coursesDirLength+1), subjectDirLength))
                    {
                        await context.StudyFiles.AddAsync(studyFile);
                    }
                }

                foreach (var file in Directory.EnumerateFiles(subjectDir))
                {
                    var fileInfo = new FileInfo(file);
                    var studyFile = new StudyFile
                    {
                        Id = Guid.NewGuid(), Course = course, Date = fileInfo.CreationTime, Name = fileInfo.Name, Size = fileInfo.Length,
                        Subject = subjectDir.Substring(coursesDirLength+1), Tags = ""
                    };
                    await context.StudyFiles.AddAsync(studyFile);
                }
            }
        }

        await context.SaveChangesAsync();
    }
    static async IAsyncEnumerable<StudyFile> ReccursiveEnum(string dir, byte course, string subject, int rootDirLength)
    {
        foreach (var innerDir in Directory.EnumerateDirectories(dir))
        {
            await foreach (var file in ReccursiveEnum(innerDir, course, subject, rootDirLength))
            {
                yield return file;
            }
        }
        foreach (var file in Directory.EnumerateFiles(dir))
        {
            var fileInfo = new FileInfo(file);
            yield return new StudyFile
            {
                Id = Guid.NewGuid(), Course = course, Date = fileInfo.CreationTime, Name = fileInfo.Name, Size = fileInfo.Length,
                Subject = subject, Tags = dir.Substring(rootDirLength+1).Replace('\\',';')
            };
        }
    }
    
}