const { getAllByDate, getAllCoursesSorted } = require('../services/courseService');

const homeController = require('express').Router();

//TODO replace with real cotroller
homeController.get('/', async (req, res) => {
    let view;
    let courses = [];

    if (req.user) {
        view = 'user-home';
        courses = await getAllByDate(req.query.search);
    } else {
        view = 'home';
        courses = await getAllCoursesSorted();
    }

    res.render(view, {
        title: 'Home Page',
        courses,
        search: req.query.search 
        
    });
});

module.exports = homeController;