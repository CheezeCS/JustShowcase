import React from "react";
import { Button, Container, Menu } from "semantic-ui-react";

export default function NavBar() {
    return (
        <Menu inverted fixed="top">
            <Container>
                <Menu.Item>
                    <img src='/logo192.png' alt="logo" />
                </Menu.Item>
                <Menu.Item>
                    <a href="/">Files</a>
                </Menu.Item>
                <Menu.Item>
                    <a href="/files">Smth</a>
                </Menu.Item>
                <Menu.Menu position="right">
                    <Menu.Item>
                        <Button inverted>Login</Button>
                    </Menu.Item>
                </Menu.Menu>
            </Container>
        </Menu>
    )
};