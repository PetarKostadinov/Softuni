const { getPlayById, updatePlay } = require('../services/playService');
const { parseError } = require('../util/parser');

const editController = require('express').Router();

editController.get('/edit/:id', async (req, res) => {

    try {
        const play = await getPlayById(req.params.id);

        if (play.owner != req.user._id) {
            throw new Error('Cannot edit play you haven\'t created');
        }

        res.render('edit', {
            title: 'Edit Play',
            play
        });
    } catch (error) {
        res.redirect('/details/' + req.params.id);
    }

});

editController.post('/edit/:id', async (req, res) => {

    try {

        const play = await getPlayById(req.params.id);

        if (play.owner != req.user._id) {
            throw new Error('Cannot edit play you haven\'t created');
        }

        await updatePlay(req.params.id, req.body);
        res.redirect('/details/' + req.params.id);
    } catch (error) {
        res.render('edit', {
            title: 'Edit Play',
            play: Object.assign(req.body, { _id: req.params._id }),
            errors: parseError(error),
        });
    }
});

module.exports = editController;