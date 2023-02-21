const { getAllPhotos } = require('../services/photoService');

const homeController = require('express').Router();

//TODO replace with real cotroller
homeController.get('/', async (req, res) => {
    let view;
    let photos = [];

    if (req.user) {
        view = 'home';
        //photos = await getAllPhotos();
    } else {
        view = 'home';
        //photos = await getAllPhotos();
    }

    res.render(view, {
        title: 'Home Page',
        photos
        
       
    });
});

module.exports = homeController;