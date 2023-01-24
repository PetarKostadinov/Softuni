const { getAllHotels } = require('../services/hotelService');

const homeController = require('express').Router();

//TODO replace with real cotroller
homeController.get('/', async (req, res) => {
    let view;
    let hotels = [];

    if (req.user) {
        view = 'home';
        hotels = await getAllHotels();
    } else {
        view = 'home';
        hotels = await getAllHotels();
    }

    res.render(view, {
        title: 'Home Page',
        hotels 
        
       
    });
});

module.exports = homeController;