
const { hasUser } = require('../middlewares/guards');
const Apart = require('../models/Apart');
const { createApart, getById, deleteById, updateById, getAllAparts, rent, getRentalsByUser, search } = require('../services/apartService');
const { parseError } = require('../util/parser');

const apartController = require('express').Router();


apartController.get('/search', hasUser(), async (req, res) => {

    let aparts = [];
    let justPage = false;

    if(req.user) {
        aparts = await search(req.query.search);
        if(req.query.search) {
            justPage = true;
        }  
    }
    
    res.render('search', {
        title: 'Search apart',
        justPage,
        aparts,
        search: req.query.search
    });
});

apartController.get('/recent', async (req, res) => {

    const aparts = await getAllAparts();

    res.render('recent', {
        title: 'Recent apart',
        aparts
    });
});

apartController.get('/create', hasUser(), (req, res) => {
    res.render('create', {
        title: 'Create apart'
    });
});

apartController.post('/create', hasUser(), async (req, res) => {
    const apart = {

        name: req.body.name,
        type: req.body.type,
        year: Number(req.body.year),
        city: req.body.city,
        image: req.body.image,
        description: req.body.description,
        available: Number(req.body.available),
        owner: req.user._id
    };

    try {
        if (Object.values(apart).some(x => !x)) {
            throw new Error('All fields are required');
        }

        await createApart(apart, apart.name);
        res.redirect('/');
    } catch (error) {
        res.render('create', {
            title: 'Create apart',
            body: apart,
            errors: parseError(error)
        });
    }
});

apartController.get('/:id/details', async (req, res) => {
    const apart = await getById(req.params.id);

    console.log(req.user)
    if (req.user) {
        apart.isOwner = apart.owner.toString() == req.user._id.toString();

        //apart.isBooked = apart.usersBooked.map(x => x.toString()).includes(req.user._id.toString());
        // apart.rentedByCurentUser = apart.rented.map(x => x.toString()).includes(req.user.name.toString());

        if (apart.rented.includes(req.user.name) || apart.rented.includes(req.user.name + ',')) {

            apart.rentedByCurentUser = true
        }
    }
    console.log(apart.isOwner)
    console.log(apart.rentedByCurentUser)

    apart.isAvailable = apart.available > 0;

    res.render('details', {
        title: apart.title,
        apart,
        //user//: Object.assign({ rented: rented.map(x => x.name) }, req.user)
    });
});

apartController.get('/:id/rent', hasUser(), async (req, res) => {
    const apart = await getById(req.params.id);

    try {
        if (apart.owner.toString() == req.user._id.toString()) {
            apart.isOwner = true;
            throw new Error('Cannot rent your own apart')
        }

        await rent(req.params.id, req.user._id, req.user.name);
        res.redirect(`/apart/${req.params.id}/details`);

    } catch (err) {

        res.render('details', {
            title: 'Apart Details',
            apart,
            errors: parseError(err)
        })
    }
})

apartController.get('/:id/delete', hasUser(), async (req, res) => {
    const apart = await getById(req.params.id);

    if (req.user) {
        if (apart.owner.toString() != req.user._id.toString()) {
            return res.redirect('/auth/login')
        }
    }

    await deleteById(req.params.id);
    res.redirect('/apart/recent');
});

apartController.get('/:id/edit', hasUser(), async (req, res) => {
    const apart = await getById(req.params.id);
    res.render('edit', {
        title: 'Edit apart',
        apart
    });

});

apartController.post('/:id/edit', hasUser(), async (req, res) => {
    const apart = await getById(req.params.id);

    if (req.user) {
        if (apart.owner.toString() != req.user._id.toString()) {
            return res.redirect('/auth/login');
        }
    }

    const edited = {
        name: req.body.name,
        type: req.body.type,
        year: req.body.year,
        city: req.body.city,
        image: req.body.image,
        description: req.body.description,
        available: Number(req.body.available)
    };

    try {
        if (Object.values(edited).some(x => !x)) {
            return new Error('All fields are required');
        }

        await updateById(req.params.id, edited);
        res.redirect(`/apart/${req.params.id}/details`);
    } catch (error) {
        const errors = parseError(error);
        //apart._id = req.params.id;
        res.render('edit', {
            title: 'Edit apart',
            apart: Object.assign(edited, { _id: req.params.id }),
            errors
        });
    }
});

module.exports = apartController;



// apartController.get('/:id/book', async (req, res) => {
//     const apart = await getById(req.params.id);

//     try {
//         if (apart.owner.toString() == req.user._id.toString()) {
//             apart.isOwner =true;
//             throw new Error('Cannot book your own apart')
//         }

//         await bookH(req.params.id, req.user._id);
//         res.redirect(`/apart/${req.params.id}/details`);

//     } catch (err) {

//         res.render('details', {
//             title: 'apart Details',
//             apart,
//             errors: parseError(err)
//         })
//     }
// })





// apartController.post('/create', async (req, res) => {
//     const apart = {
//         title: req.body.title,
//         description: req.body.description,
//         imageUrl: req.body.imageUrl,
//         duration: req.body.duration,
//         owner: req.user._id
//     };

//     try {
//         await createapart(apart);
//         res.redirect('/');
//     } catch (error) {
//         res.render('create', {
//             title: 'Create apart',
//             errors: parseError(error),
//             body: apart
//         });
//     }

// });

// apartController.get('/:id/edit', async (req, res) => {
//     const apart = await getById(req.params.id);
//     res.render('edit', {
//         title: 'Edit apart',
//         apart
//     });

// });

// apartController.post('/:id/edit', async (req, res) => {
//     const apart = await getById(req.params.id);

//     if (apart.owner.toString() != req.user._id.toString()) {
//         return res.redirect('/auth/login');
//     }

//     try {
//         await updateById(req.params.id, req.body);
//         res.redirect(`/apart/${req.params.id}`);
//     } catch (error) {
//         res.render('edit', {
//             title: 'Edit apart',
//             errors: parseError(error),
//             apart: req.body
//         });
//     }
// });

// apartController.get('/:id/enroll', async (req, res) => {
//     const apart = await getById(req.params.id);

//     if (apart.owner.toString() != req.user._id.toString()
//         && apart.users.map(x => x.toString()).includes(req.user._id.toString()) == false) {

//         await enrollUser(req.params.id, req.user._id);
//     }

//     res.redirect(`/apart/${req.params.id}`);
// });

