const { hasUser } = require('../middlewares/guards');
const { vote, getPlayById } = require('../services/playService');

const likeController = require('express').Router();
const { parseError } = require('../util/parser')

likeController.get('/like/:id', hasUser(), async (req, res) => {
    const play = await getPlayById(req.params.id);

    try {
        if (play.owner == req.user._id) {
            play.isOwner = true;
            throw new Error('Cannot like your own play')
        }

        await vote(req.params.id, req.user._id);
        res.redirect(`/details/${req.params.id}`);
    } catch (err) {
        res.render('details', {
            title: 'Hotel Details',
            errors: parseError(err),
            play
        });
    }
});

module.exports = likeController;

