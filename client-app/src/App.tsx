import React, { Component } from "react";
import { Header, Icon, List } from "semantic-ui-react";
import "./App.css";
import axios from "axios";

class App extends Component {
  state = {
    values: []
  }

  componentDidMount() {
    axios.get("http://localhost:5000/api/values").then(res => {
      this.setState({
        values: res.data
      })
    })
  }

  render() {
    return (
      <div>
        <Header as="h2">
          <Icon name="users" />
          <Header.Content>reactivities</Header.Content>
        </Header>
        
        <List>
          {this.state.values.map((el: any) => (
            <List.Item key={el.id}>{el.name}</List.Item>
          ))}
        </List>
      </div>
    )
  }
}

export default App;
