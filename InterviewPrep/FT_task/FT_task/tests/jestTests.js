import {fetchData} from '../src/fetchData.js';
import fetchMock from 'jest-fetch-mock';

describe('fetchData', () => {
    beforeEach(() => {
        fetchMock.resetMocks();
    });

    it('should fetch data successfully', async () => {
        const mockData = {
            data: {
                quotes: {
                    items: [
                        {
                            symbolInput: 'FTSE:FSI',
                            quote: {
                                change1Day: expect.any(Number),
                                change1DayPercent: expect.any(Number),
                            },
                        }
                    ],
                },
            },
        };

        fetchMock.mockResponseOnce(JSON.stringify(mockData));

        const responseData = await fetchData();

        expect(fetchMock).toHaveBeenCalledWith(
            'http://localhost:3000/graphql',
            expect.objectContaining({
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    query: expect.any(String),
                }),
            })
        );

        expect(responseData).toMatchObject(mockData.data.quotes.items[0]);
    });

    it('should return an empty array if the request fails', async () => {
        fetchMock.mockRejectOnce();

        const responseData = await fetchData();

        expect(responseData).toEqual([]);

    });


});
