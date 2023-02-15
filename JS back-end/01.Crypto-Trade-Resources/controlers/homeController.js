const { getAllCryptos } = require('../services/cryptoService');

const homeController = require('express').Router();

//TODO replace with real cotroller
homeController.get('/', async (req, res) => {
    let view;
    let hotels = [];

    if (req.user) {
        view = 'home';
        hotels = await getAllCryptos();
    } else {
        view = 'home';
        hotels = await getAllCryptos();
    }

    res.render(view, {
        title: 'Home Page',
        hotels 
        
       
    });
});

module.exports = homeController;