import { get, del, put, post } from "./api.js";

export async function getAll() {
    return get('/data/albums?sortBy=_createdOn%20desc&distinct=name');

}

export async function getById(id) {
    return get('/data/albums/' + id);
}

export async function deleteById(id) {
    return del('/data/albums/' + id);
}

export async function create(data) {

    return post('/data/albums', data);
}

export async function edit(id, petData) {
    return put('/data/albums/' + id, petData);
}

export async function getSearched(query) {
    return get(`/data/albums?where=name%20LIKE%20%22${query}%22`);
}