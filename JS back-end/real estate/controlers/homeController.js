const { getLimitedAparts } = require('../services/apartService');

const homeController = require('express').Router();

//TODO replace with real cotroller
homeController.get('/', async (req, res) => {
    let view;
    let aparts = [];

    if (req.user) {
        view = 'home';
        aparts = await getLimitedAparts();
    } else {
        view = 'home';
        aparts = await getLimitedAparts();
    }

    res.render(view, {
        title: 'Home Page',
        aparts 
    });
});

module.exports = homeController;