const { hasUser } = require('../middlewares/guards');
const { deletePost, getPostById } = require('../services/postService');
const { postViewModels } = require('../util/parser');
const deleteController = require('express').Router();

deleteController.get('/delete/:id', hasUser(), async (req, res) => {
    const id = req.params.id;
    const existing = postViewModels(await getPostById(id));

    if (req.session.user._id != existing.author._id) {
        return res.redirect('/auth/login');
    }

    try {
        await deletePost(id);
        res.redirect('/catalog');
    } catch (err) {
        console.error(err);
        const errors = parseError(err);
        post._id = id;
        res.render('details', {
            title: existing.title,
            errors
        });
    }
});

module.exports = deleteController;