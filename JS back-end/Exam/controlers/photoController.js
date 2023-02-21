const { hasUser } = require('../middlewares/guards');
const User = require('../models/User');
const { createPhoto, getById, deleteById, updateById, comment, getAllPhotos } = require('../services/photoService');
const { parseError } = require('../util/parser');

const photoController = require('express').Router();

photoController.get('/catalog', async (req, res) => {
  const photos = await getAllPhotos()
    res.render('catalog', {
        title: 'Catalog',
        photos
    });
});

photoController.get('/create', hasUser(), (req, res) => {
    res.render('create', {
        title: 'Create Photo'
    });
});

photoController.post('/create', hasUser(), async (req, res) => {
    const photo = {

        name: req.body.name,
        age: Number(req.body.age),
        image: req.body.image,
        description: req.body.description,
        location: req.body.location,
        owner: req.user._id
    };

    try {
        if (Object.values(photo).some(x => !x)) {
            throw new Error('All fields are required');
        }

        await createPhoto(photo);
        res.redirect('/photo/catalog');
    } catch (error) {
        res.render('create', {
            title: 'Create Photo',
            body: photo,
            errors: parseError(error)
        });
    }
});

photoController.get('/:id/details', async (req, res) => {
    const photo = await getById(req.params.id);
    const user = await User.findById(photo.owner.toString());
    photo.username = user.username
    console.log(user.username)
   if(req.user) {
   
    photo.isOwner = photo.owner.toString() == req.user._id.toString();
 
   }
    
    res.render('details', {
        title: photo.title,
        photo,
      
    });
});

photoController.get('/:id/delete', hasUser(), async (req, res) => {
    const photo = await getById(req.params.id);

    if (photo.owner.toString() != req.user._id.toString()) {
        return res.redirect('/auth/login')
    }

    await deleteById(req.params.id);
    res.redirect('/catalog');
});

photoController.get('/:id/edit', hasUser(), async (req, res) => {
    const photo = await getById(req.params.id);
    res.render('edit', {
        title: 'Edit photo',
        photo
    });

});

photoController.post('/:id/edit', hasUser(), async (req, res) => {
    const photo = await getById(req.params.id);

    if (photo.owner.toString() != req.user._id.toString()) {
        return res.redirect('/auth/login');
    }

    const edited = {
        name: req.body.name,
        age: Number(req.body.age),
        image: req.body.image,
        description: req.body.description,
        location: req.body.location,
        owner: req.user._id
    }
    try {
        if (Object.values(edited).some(x => !x)) {
            return new Error('All fields are required');
        }

        await updateById(req.params.id, edited);
        res.redirect(`/photo/${req.params.id}/details`);
    } catch (error) {
        const errors = parseError(error);
       
        res.render('edit', {
            title: 'Edit hotel',
            photo: Object.assign(edited, { _id: req.params.id }),
            errors
        });
    }
});

photoController.post('/:id/comment', hasUser(), async (req, res) => {
    const photo = await getById(req.params.id);
    
    try {
        if (photo.owner.toString() == req.user._id.toString()) {
            photo.isOwner =true;
            throw new Error('Cannot comment your own photo')
        }

        await comment(req.user.username, req.body.comment, req.user._id, req.params.id );
        res.redirect(`/photo/${req.params.id}/details`);

    } catch (err) {

        res.render('details', {
            title: 'Photo Details',
            photo,
            errors: parseError(err)
        })
    }
})



module.exports = photoController;



// photoController.post('/create', async (req, res) => {
//     const hotel = {
//         title: req.body.title,
//         description: req.body.description,
//         imageUrl: req.body.imageUrl,
//         duration: req.body.duration,
//         owner: req.user._id
//     };

//     try {
//         await createPhoto(hotel);
//         res.redirect('/');
//     } catch (error) {
//         res.render('create', {
//             title: 'Create hotel',
//             errors: parseError(error),
//             body: hotel
//         });
//     }

// });

// photoController.get('/:id/edit', async (req, res) => {
//     const hotel = await getById(req.params.id);
//     res.render('edit', {
//         title: 'Edit hotel',
//         hotel
//     });

// });

// photoController.post('/:id/edit', async (req, res) => {
//     const hotel = await getById(req.params.id);

//     if (hotel.owner.toString() != req.user._id.toString()) {
//         return res.redirect('/auth/login');
//     }

//     try {
//         await updateById(req.params.id, req.body);
//         res.redirect(`/hotel/${req.params.id}`);
//     } catch (error) {
//         res.render('edit', {
//             title: 'Edit hotel',
//             errors: parseError(error),
//             hotel: req.body
//         });
//     }
// });

// photoController.get('/:id/enroll', async (req, res) => {
//     const hotel = await getById(req.params.id);

//     if (hotel.owner.toString() != req.user._id.toString()
//         && hotel.users.map(x => x.toString()).includes(req.user._id.toString()) == false) {

//         await enrollUser(req.params.id, req.user._id);
//     }

//     res.redirect(`/hotel/${req.params.id}`);
// });

