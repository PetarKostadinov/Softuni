const { query } = require('express');
const {
    hasUser
} = require('../middlewares/guards');
const {
    createCrypto,
    getById,
    deleteById,
    updateById,
    buy,
    getAllCryptos,
    search
} = require('../services/cryptoService');
const { paymentMethodsMap } = require('../util/constants');
const {
    parseError
} = require('../util/parser');

const cryptoController = require('express').Router();

cryptoController.get('/catalog', async (req, res) => {

    const cryptos = await getAllCryptos()
    res.render('catalog', {
        title: 'Catalog crypto',
        cryptos
    });
});

cryptoController.get('/404', (req, res) => {
    res.render('404', {
        title: 'Not found'
    });
});


cryptoController.get('/create', hasUser(), (req, res) => {
    const paymentMethods = Object.keys(paymentMethodsMap)
    .map(x => ({
        value: x, 
        label: paymentMethodsMap[x],
        isSelected: true
    
    }));
    res.render('create', {
        title: 'Create crypto',
        paymentMethods
    });
});

cryptoController.post('/create', hasUser(), async (req, res) => {
    const crypto = {

        name: req.body.name,
        image: req.body.image,
        price: Number(req.body.price),
        description: req.body.description,
        payment: req.body.payment,
        buyCryptoUsers: [],
        owner: req.user._id
    };

    try {
        if (Object.values(crypto).some(x => !x)) {
            throw new Error('All fields are required');
        }

        await createCrypto(crypto);
        res.redirect('/crypto/catalog');
    } catch (error) {
        res.render('create', {
            title: 'Create crypto',
            body: crypto,
            errors: parseError(error)
        });
    }
});

cryptoController.get('/:id/details', async (req, res) => {
    const crypto = await getById(req.params.id);

    const paymentMethods = Object.keys(paymentMethodsMap)
    .map(x => ({
        value: x, 
        label: paymentMethodsMap[x],
        isSelected: crypto.payment == x
    
    }));
    //console.log(crypto.owner.toString())

    if (req.user) {
        crypto.isOwner = crypto.owner.toString() == req.user._id.toString();
        crypto.isBought = crypto.buyCryptoUsers.map(x => x.toString()).includes(req.user._id.toString());

    }
    console.log(paymentMethods)

    res.render('details', {
        title: crypto.title,
        crypto,
        paymentMethods
    });
});

cryptoController.get('/:id/delete', hasUser(), async (req, res) => {
    const crypto = await getById(req.params.id);

    if (crypto.owner.toString() != req.user._id.toString()) {
        return res.redirect('/auth/login')
    }

    await deleteById(req.params.id);
    res.redirect('/crypto/catalog');
});

cryptoController.get('/:id/edit', hasUser(), async (req, res) => {
    const crypto = await getById(req.params.id);
    const paymentMethods = Object.keys(paymentMethodsMap)
    .map(x => ({
        value: x, 
        label: paymentMethodsMap[x],
        isSelected: crypto.payment == x
    
    }));


    res.render('edit', {
        title: 'Edit crypto',
        crypto,
        paymentMethods
    });

});

cryptoController.post('/:id/edit', hasUser(), async (req, res) => {
    const crypto = await getById(req.params.id);

    if (crypto.owner.toString() != req.user._id.toString()) {
        return res.redirect('/auth/login');
    }

    const edited = {

        name: req.body.name,
        image: req.body.image,
        price: Number(req.body.price),
        description: req.body.description,
        payment: req.body.payment

    };
    console.log(edited.payment)

    try {
        if (Object.values(edited).some(x => !x)) {
            return new Error('All fields are required');
        }

        // if(edited.name.length < 4) {
        //     return new Error('N')
        // }

        await updateById(req.params.id, edited);
        res.redirect(`/crypto/${req.params.id}/details`);
    } catch (error) {
        const errors = parseError(error);
        //crypto._id = req.params.id;
        res.render('edit', {
            title: 'Edit crypto',
            crypto: Object.assign(edited, {
                _id: req.params.id
            }),
            errors
        });
    }
});

cryptoController.get('/:id/buy', hasUser(), async (req, res) => {
    const crypto = await getById(req.params.id);

    try {
        if (crypto.owner.toString() == req.user._id.toString()) {
            crypto.isOwner = true;
            throw new Error('Cannot buy your own crypto')
        }

        await buy(req.params.id, req.user._id);
        res.redirect(`/crypto/${req.params.id}/details`);

    } catch (err) {

        res.render('details', {
            title: 'Crypto Details',
            crypto,
            errors: parseError(err)
        })
    }
})

cryptoController.get('/search', hasUser(), async (req, res) => {
    const crypto = await getById(req.params.id);
    const paymentMethods = Object.keys(paymentMethodsMap)
    .map(x => ({
        value: x, 
        label: paymentMethodsMap[x]
       
    
    }));

    let cryptos = [];
    //let justPage = false;
    
    if (req.user) {
        cryptos = await search(req.query.searchName, req.query.searchPayment);
      
        
    }

    res.render('search', {
        title: 'Search cryptos',
        cryptos,
        searchedName: req.query.searchName,
        searchedPay: req.query.searchPayment,
        paymentMethods
        
        
    });
});



module.exports = cryptoController;



// cryptoController.post('/create', async (req, res) => {
//     const crypto = {
//         title: req.body.title,
//         description: req.body.description,
//         imageUrl: req.body.imageUrl,
//         duration: req.body.duration,
//         owner: req.user._id
//     };

//     try {
//         await createcrypto(crypto);
//         res.redirect('/');
//     } catch (error) {
//         res.render('create', {
//             title: 'Create crypto',
//             errors: parseError(error),
//             body: crypto
//         });
//     }

// });

// cryptoController.get('/:id/edit', async (req, res) => {
//     const crypto = await getById(req.params.id);
//     res.render('edit', {
//         title: 'Edit crypto',
//         crypto
//     });

// });

// cryptoController.post('/:id/edit', async (req, res) => {
//     const crypto = await getById(req.params.id);

//     if (crypto.owner.toString() != req.user._id.toString()) {
//         return res.redirect('/auth/login');
//     }

//     try {
//         await updateById(req.params.id, req.body);
//         res.redirect(`/crypto/${req.params.id}`);
//     } catch (error) {
//         res.render('edit', {
//             title: 'Edit crypto',
//             errors: parseError(error),
//             crypto: req.body
//         });
//     }
// });

// cryptoController.get('/:id/enroll', async (req, res) => {
//     const crypto = await getById(req.params.id);

//     if (crypto.owner.toString() != req.user._id.toString()
//         && crypto.users.map(x => x.toString()).includes(req.user._id.toString()) == false) {

//         await enrollUser(req.params.id, req.user._id);
//     }

//     res.redirect(`/crypto/${req.params.id}`);
// });