import React, { useEffect, useState } from 'react'

function ProductsList() {

    const [items, setItems] = useState([]);
    const [page, setPage] = useState(1);
    const [total, setTotal] = useState(0);

    const fetchData = async () => {
        const res = await fetch(`https://dummyjson.com/products?limit=10&skip=${page * 10 - 10}`)
        const data = await res.json()
        console.log(data)

        if (data && data.products) {
            setItems(data.products);
            setTotal(data.total / 10)
        }
    }

    useEffect(() => {
        fetchData();
    }, [page]);

    const selectedPageHandler = (selectedPage) => {


        if (selectedPage >= 1
            && selectedPage <= total
            && selectedPage !== page) {
            setPage(selectedPage);
        }
        // window.scrollTo({ top: 0 });
    }

    return (
        <div>
            {items.length > 0 && (
                <div className='products'>
                    {items.map((x) => {
                        return <div className="card" style={{ width: '18rem' }} key={x.id}>
                            <img src={x.thumbnail} className="card-img-top" alt={x.title} />
                            <div className="card-body">
                                <h5 className="card-title">{x.title}</h5>
                                <p className="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>

                            </div>
                        </div>
                    })}
                </div>
            )}
            {items.length > 0 && <div className='pagination'>
                <span
                    key={page}
                    onClick={() => selectedPageHandler(page - 1)}
                    className={page > 1 ? '' : 'pagination__disabled'}
                >
                    ◀️
                </span>
                {
                    [...Array(total)].map((_, i) => {
                        return <span
                            className={page === i + 1 ? 'pagination__selected' : ''}
                            onClick={() => selectedPageHandler(i + 1)}
                            key={i}
                        >
                            {i + 1}
                        </span>
                    })
                }

                <span
                    key={page + 2}
                    onClick={() => selectedPageHandler(page + 1)}
                    className={page < total ? '' : 'pagination__disabled'}
                >
                    ▶️
                </span>
            </div>}

        </div>
    )
}

export default ProductsList;
