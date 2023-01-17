const router = require('express').Router();
const { hasUser } = require('../middlewares/guards');
const { createPost } = require('../services/postService');
const { parseError } = require('../util/parser');

router.get('/create', hasUser(), (req, res) => {
    res.render('create', {
        title: 'Create Post'
    });
});

router.post('/create', hasUser(), async (req, res) => {
    const userId = req.session.user._id;
    const post = {
        title: req.body.title,
        keyword: req.body.keyword,
        location: req.body.location,
        date: req.body.date,
        image: req.body.image,
        description: req.body.description,
        author: userId
    };
    try {
        await createPost(post);
        res.redirect('/catalog');
    } catch (err) {
        console.log(err)
        const errors = parseError(err);
        res.render('create', {
            title: 'Create Post',
            errors,
            data: post
        });
    }
});

module.exports = router;