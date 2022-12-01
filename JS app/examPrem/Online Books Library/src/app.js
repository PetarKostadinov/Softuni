
import {render, page} from './lib.js';
import { getUserData } from './util.js';
import { showCatalog } from './views/catalog.js';
import { showCreate } from './views/create.js';
import { showDetails } from './views/details.js';
import { showEdit } from './views/edit.js';
//import { showHome } from './views/home.js';
import { showLogin } from './views/login.js';
import { updateNav } from './views/nav.js';
import { showMyBooks } from './views/ownBooks.js';
import { showRegister } from './views/register.js';


const main  = document.getElementById('site-content');

page(decorateContext);
//page('/', showHome);
page('/', showCatalog);
page('/catalog/:id', showDetails);
page('/login', showLogin);
page('/register', showRegister);
page('/create', showCreate);
page('/edit/:id', showEdit);
page('/myBook', showMyBooks);

updateNav();
page.start();

function decorateContext(ctx, next){
    ctx.render = renderMain;
    ctx.updateNav = updateNav;

    const user = getUserData();

    if(user){

        ctx.user = user;
    }

    next();
}

function renderMain (content){
    render(content, main);
}



