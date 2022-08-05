import React, { Fragment, useEffect, useState } from 'react';

import './App.css';
import axios from 'axios';
import { Container} from 'semantic-ui-react';
import NavBar from './layout/NavBar';
import './semantic-ui/semantic.min.css';
import { StudyFiles} from './app/models/studyFile';
import CourseGrid from './app/dashboard/dashboard';
function App() {
  return (
    <Fragment>
      <NavBar />
      <Container style={{marginTop:'6em'}}>
       <CourseGrid/>
       </Container>
    </Fragment>
  );
}

export default App;
