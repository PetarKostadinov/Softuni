
const { getPostById } = require('../services/postService');
const { postViewModels } = require('../util/parser');
const detailsController = require('express').Router();

detailsController.get('/catalog/:id', async (req, res) => {
    const id = req.params.id;
    const post = postViewModels(await getPostById(id))

    if (req.session.user) {
        post.hasUser = true;

        if (req.session.user._id == post.author._id) {
            post.isAuthor = true;
        } else {
            post.hasVoted = post.votes.find(v => v._id == req.session.user._id) != undefined;
        }
    }

    res.render('details', {
        title: post.title,
        post
    });
});

module.exports = detailsController;
