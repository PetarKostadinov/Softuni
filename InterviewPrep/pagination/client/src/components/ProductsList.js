import React, { useEffect, useState } from 'react'
import { bootstrap } from 'bootstrap'

function ProductsList() {

    const [items, setItems] = useState([]);

    const fetchData = async () => {
        const res = await fetch('https://dummyjson.com/products')
        const data = await res.json()
        console.log(data)

        if (data && data.products) {
            setItems(data.products);
        }


    }

    useEffect(() => {
        fetchData();
    }, [])


    return (
        <div >
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

        </div>
    )
}

export default ProductsList;
