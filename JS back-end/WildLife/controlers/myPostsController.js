const { hasUser } = require('../middlewares/guards');
const { getPostByAuthor } = require('../services/postService');
const { postViewModels } = require('../util/parser');
const myPostsController = require('express').Router();

myPostsController.get('/profile', hasUser(), async (req, res) => {

    const posts = (await getPostByAuthor(req.session.user._id)).map(postViewModels);
    res.render('profile', {
        title: 'My Posts',
        posts
    })

});

module.exports = myPostsController;