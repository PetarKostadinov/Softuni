const express = require('express');
const {ApolloServer} = require('apollo-server-express');
const path = require('path');
const typeDefs = require('./schema/type-defs');
const resolvers = require('./schema/resolvers');

const app = express();
const port = 3000;

const server = new ApolloServer({typeDefs, resolvers});

async function startApolloServer() {
    await server.start();
    server.applyMiddleware({app});
}

app.use(express.static(path.join(__dirname, '../FT_task/src')));
app.use('/styles', express.static(path.join(__dirname, '../FT_task/styles')));

startApolloServer().then(() => {
    app.listen(port, () => {
        console.log(`Your API is running on http://localhost:${port}/graphql`);
        console.log(`Your frontend is running on http://localhost:${port}/`);
    });
}).catch((error) => {
    console.error('Failed to start Apollo Server:', error);
});
