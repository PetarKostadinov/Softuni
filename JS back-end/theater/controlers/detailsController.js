const { hasUser } = require('../middlewares/guards');
const { getPlayById } = require('../services/playService');

const detailsController = require('express').Router();

detailsController.get('/details/:id',hasUser(), async (req, res) => {

    try {
        const play = await getPlayById(req.params.id);
        play.isLiked = play.usersLiked.find(v => v._id == req.user._id) != undefined;
        

        if (play.owner == req.user._id) {
            play.isOwner = true;
        }

        res.render('details', {
            title: 'Play Details',
            play
        });

    } catch (error) {
        res.redirect('/404')
    }
});

module.exports = detailsController;
