import { get, del, put, post } from "./api.js";

export async function getAll() {
    return get('/data/books?sortBy=_createdOn%20desc');

}

export async function getById(id) {
    return get('/data/books/' + id);
}

export async function deleteById(id) {
    return del('/data/books/' + id);
}       

export async function create(users) {

    return post('/data/books', users);
}

export async function edit(id, users) {
    return put('/data/books/' + id, users);
}

export async function getSearched(userId) {
    return get(`/data/books?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

export async function postLike(bookId){

    return post('/data/likes', {bookId})
}

export async function getTotatlLikes(bookId){

    return get(`/data/likes?where=bookId%3D%22${bookId}%22&distinct=_ownerId&count`)
}

export async function getLikesForSpecUser(bookId, userId){

    return get(`/data/likes?where=bookId%3D%22${bookId}%22%20and%20_ownerId%3D%22${userId}%22&count`)
}