const { hasUser } = require('../middlewares/guards');
const { getPostById, updatePost } = require('../services/postService');
const { postViewModels, parseError } = require('../util/parser');
const editController = require('express').Router();

editController.get('/edit/:id', hasUser(), async (req, res) => {
    const id = req.params.id;
    const post = postViewModels(await getPostById(id));

    if (req.session.user._id != post.author._id) {
        return res.redirect('/auth/login');
    }
    res.render('edit', {
        title: 'Edit',
        post
    });
});

editController.post('/edit/:id', hasUser(), async (req, res) => {
    const id = req.params.id;
    const existing = postViewModels(await getPostById(id));

    if (req.session.user._id != existing.author._id) {
        return res.redirect('/auth/login');
    }

    const post = {
        title: req.body.title,
        keyword: req.body.keyword,
        location: req.body.location,
        date: req.body.date,
        image: req.body.image,
        description: req.body.description,
    };

    try {
        await updatePost(id, post);
        res.redirect('/catalog/' + id);
    } catch (err) {
        console.error(err);
        const errors = parseError(err);
        post._id = id;
        res.render('edit', {
            title: 'Edit',
            post,
            errors
        });
    }
});

module.exports = editController;