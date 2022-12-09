import { get, del, put, post } from "./api.js";

export async function getAll() {
    return get('/data/memes?sortBy=_createdOn%20desc');

}

export async function getById(id) {
    return get('/data/memes/' + id);
}

export async function deleteById(id) {
    return del('/data/memes/' + id);
}

export async function create(data) {

    return post('/data/memes', data);
}

export async function edit(id, data) {
    return put('/data/memes/' + id, data);
}

export async function getOwnMemes(userId) {
    return get(`/data/memes?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}