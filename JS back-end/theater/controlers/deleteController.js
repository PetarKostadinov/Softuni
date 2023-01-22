const { deletePlay, getPlayById } = require('../services/playService');
const deleteController = require('express').Router();

deleteController.get('/delete/:id', async (req, res) => {

    try {
        const play = await getPlayById(req.params.id);

        if (play.owner != req.user._id) {
            throw new Error('Cannot delete play you haven\'t created');
        }

        await deletePlay(req.params.id)
        res.redirect('/')
    } catch (error) {
        res.redirect('/details/' + req.params.id);
    }
});

module.exports = deleteController;

