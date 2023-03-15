const express = require('express');
const expressCnfig = require('./config/express');
const databaseConfig = require('./config/database');
const routesConfig = require('./config/routes');

start();

async function start() {
    const app = express();

    expressCnfig(app);
    await databaseConfig(app);
    routesConfig(app);

    app.listen(3000, () => console.log('Server listening on  port 3000'));
}




