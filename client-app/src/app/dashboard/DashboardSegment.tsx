import { Icon, Item, ItemContent, List, Segment } from "semantic-ui-react";
import { StudyFiles } from "../models/studyFile";
import axios from 'axios';
import { useEffect, useState } from "react";
import moment from "moment";
import '../../styles.css';

import {
    BrowserRouter as Router,
    Routes,
    Route,
    Link,
    useMatch,
    useParams
} from "react-router-dom";
import React from "react";

interface Props {
    studyFiles: StudyFiles[];
}
interface ParamTypes {
    id: string
}




export default function DashboardSegment() {


    let { id } = useParams<string>();
    if (id) {
        id = id[0];
    }
    console.log(id);
    const [studyFiles, setStudyFiles] = useState<StudyFiles[]>([]);
    useEffect(() => {
        axios.get<StudyFiles[]>('http://localhost:5186/api/StudyFiles/' + id).then(resp => {
            console.log(resp);
            setStudyFiles(resp.data);
        })
    }, [])
    return (
        <Segment>
            <Item.Group divided>
                {studyFiles.map(x => x.subject).filter((v, i, a) => a.indexOf(v) == i).map(subject => (
                    <Item key={subject} as='a' >
                        <Item.Content>
                            <Item.Image><Icon name='folder' size='massive' ></Icon></Item.Image>
                            <Item.Header>{subject}</Item.Header>
                            <Item.Description>
                                <Item.Group divided className='folders'>
                                    {studyFiles.filter(x => x.subject == subject).map(x => (
                                        <Item key={x.id}>
                                            <Item.Content>
                                                <Item.Header as='a' href={'/studyFile/' + x.id}>{x.name}</Item.Header>
                                                <Item.Description>{moment(x.date).format('DD.MM.YYYY')}</Item.Description>
                                            </Item.Content>
                                        </Item>
                                    ))}
                                </Item.Group>
                            </Item.Description>
                        </Item.Content>
                    </Item>
                ))}
            </Item.Group>
        </Segment>
    )
};