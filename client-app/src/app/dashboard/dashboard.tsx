
import { Icon, Grid, List, Card } from "semantic-ui-react";
import {
    BrowserRouter as Router,
    Routes,
    Route,
    Link,
    useMatch,
    useParams
} from "react-router-dom";
import DashboardSegment from "./DashboardSegment";

export default function CourseGrid() {
    return (
        <Router>
            <Grid doubling={true} columns='5'>
                <Grid.Column>
                    <Card as='a' href="/1 курс">
                        <Icon name='folder' size='massive' ></Icon>
                        <Card.Content>
                            <Card.Header>1 курс</Card.Header>
                            <Card.Meta>
                                <span className='date'>Created:</span>
                                <span className='date'>10/10/2019</span>
                            </Card.Meta>
                        </Card.Content>
                    </Card>
                </Grid.Column>
                <Grid.Column>
                    <Card as='a' href="/2 курс">
                        <Icon name='folder' size='massive' ></Icon>
                        <Card.Content>
                            <Card.Header>2 курс</Card.Header>
                            <Card.Meta>
                                <span className='date'>Created:</span>
                                <span className='date'>10/10/2019</span>
                            </Card.Meta>
                        </Card.Content>
                    </Card>
                </Grid.Column>
                <Grid.Column>
                    <Card as='a' href="/3 курс">
                        <Icon name='folder' size='massive' ></Icon>
                        <Card.Content>
                            <Card.Header>3 курс</Card.Header>
                            <Card.Meta>
                                <span className='date'>Created:</span>
                                <span className='date'>10/10/2019</span>
                            </Card.Meta>
                        </Card.Content>
                    </Card>
                </Grid.Column>
                <Grid.Column>
                    <Card as='a' href="/4 курс">
                        <Icon name='folder' size='massive' ></Icon>
                        <Card.Content>
                            <Card.Header>4 курс</Card.Header>
                            <Card.Meta>
                                <span className='date'>Created:</span>
                                <span className='date'>10/10/2019</span>
                            </Card.Meta>
                        </Card.Content>
                    </Card>
                </Grid.Column>
                <Grid.Column>
                    <Card as='a' href="/5 курс">
                        <Icon name='folder' size='massive' ></Icon>
                        <Card.Content>
                            <Card.Header>5 курс</Card.Header>
                            <Card.Meta>
                                <span className='date'>Created:</span>
                                <span className='date'>10/10/2019</span>
                            </Card.Meta>
                        </Card.Content>
                    </Card>
                </Grid.Column>
            </Grid>

            <Routes>
                <Route path="/:id" element={<DashboardSegment/>} />
            </Routes>
        </Router>
    );
}