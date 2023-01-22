const { hasUser } = require('../middlewares/guards');
const { getAllByDate, getRecent, getAllPlays } = require('../services/playService');

const homeController = require('express').Router();

let view;
let plays = [];
//TODO replace with real cotroller
homeController.get('/', async (req, res) => {
  console.log(req.query)
  if (req.user) {
    view = 'userHome';
    plays = await getAllPlays(req.query.orderBy);
    
  } else {
    view = 'guestHome';
    plays = await getRecent()
   
  }

  res.render(view, {
    title: 'Home Page',
    plays,
    
  });
});



//TODO replace with real cotroller
// homeController.get('/', async (req, res) => {
//   const hotels = await getAll();
//   res.render('home', {
//     title: 'Home Page',
//     hotels
//   });
// });

module.exports = homeController;

