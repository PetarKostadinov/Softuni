import { get, del, put, post } from "./api.js";

export async function getAll() {
    return get('/data/albums?sortBy=_createdOn%20desc');

}

export async function getById(id) {
    return get('/data/albums/' + id);
}

export async function deleteById(id) {
    return del('/data/albums/' + id);
}       

export async function create(users) {

    return post('/data/albums', users);
}

export async function edit(id, users) {
    return put('/data/albums/' + id, users);
}

export async function getSearched(userId) {
    return get(`/data/albums?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

export async function postLike(albumId){

    return post('/data/likes', {albumId})
}

export async function getTotatlLikes(albumId){

    return get(`/data/likes?where=albumId%3D%22${albumId}%22&distinct=_ownerId&count`)
}

export async function getLikesForSpecUser(albumId, userId){

    return get(`/data/likes?where=albumId%3D%22${albumId}%22%20and%20_ownerId%3D%22${userId}%22&count`)
}