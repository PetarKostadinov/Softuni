const homeController = require('express').Router();

//TODO replace with real cotroller
homeController.get('/', async (req, res) => {

    res.render('home', {
        title: 'Home Page'
    });
});

module.exports = homeController;