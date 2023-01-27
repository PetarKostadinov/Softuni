const mongoose = require('mongoose');

//TODO change database acording to assignment
const CONECTION_STRING = 'mongodb://localhost:27017/realEstate';
mongoose.set("strictQuery", false);
module.exports = async (app) => {
    try {
        await mongoose.connect(CONECTION_STRING, {
            useNewUrlParser: true,
            useUnifiedTopology: true
        });
        console.log('Database Conected')
    } catch (err) {
        console.error(err.message);
        process.exit(1);
    }
};