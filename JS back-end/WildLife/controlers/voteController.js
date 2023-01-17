const { hasUser } = require('../middlewares/guards');
const { vote } = require('../services/postService');
const { parseError } = require('../util/parser');
const voteController = require('express').Router();

voteController.get('/vote/:id/:type', hasUser(), async (req, res) => {
    const id = req.params.id;
    const value = req.params.type == 'upvote' ? 1 : -1;

    try {
        await vote(id, req.session.user._id, value);
        res.redirect('/catalog/' + id);
    } catch (err) {
        console.error(err);
        const errors = parseError(err);
        res.render('details', {
            title: 'Details',
            errors
        });
    }
});

module.exports = voteController;