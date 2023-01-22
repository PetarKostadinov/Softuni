const playController = require('express').Router();
const { hasUser } = require('../middlewares/guards');
const { createPlay } = require('../services/playService');
const { parseError } = require('../util/parser');

playController.get('/create', hasUser(), (req, res) => {
    res.render('create', {
        title: 'Create play'
    });
});

playController.post('/create', hasUser(), async (req, res) => {
    const userId = req.user._id;
    const play = {
        _id: req.body._id,
        name: req.body.name,
        description: req.body.description,
        image: req.body.image,
        isPublic: Boolean(req.body.isPublic),
        owner: req.user._id
    };

    try {
        await createPlay(play, req.body);
        res.redirect('/');
    } catch (err) {

        const errors = parseError(err);
        res.render('create', {
            title: 'Create play',
            errors,
            data: play
        });
    }
});

module.exports = playController;