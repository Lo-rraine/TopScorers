import React from "react";
import { ApolloProvider } from "@apollo/react-hooks";
import ApolloClient from "apollo-boost";
import { gql } from "graphql-tag";
import "./App.css";

const client = new ApolloClient({
  uri: "http://localhost:5000/graphql", // Replace with your server URL
});

function App() {
  const [topScorers, setTopScorers] = React.useState([]);
  const [highestScore, setHighestScore] = React.useState(null);

  React.useEffect(() => {
    client
      .query({
        query: gql`
          query {
            highestScore
            topScorers
          }
        `,
      })
      .then((result) => {
        setTopScorers(result.data.topScorers);
        setHighestScore(result.data.highestScore);
      })
      .catch((error) => {
        console.error("Error:", error);
      });
  }, []);

  return (
    <ApolloProvider client={client}>
      <div className="main">
        <div className="container"></div>
        <div className="data">
          <div>
            <h1>Top Scorers</h1>
            {topScorers.map((scorer, index) => (
              <p key={index}>{scorer}</p>
            ))}
          </div>
          <div>
            <h1>Highest Score</h1>
            <p>{highestScore}</p>
          </div>
        </div>
      </div>
    </ApolloProvider>
  );
}

export default App;
