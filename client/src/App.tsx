import React, {useEffect} from 'react';
import {createOffer, getOffers, getPopularSuppliers} from "./api";
import {useDebounce} from "./hooks/useDebounce";
import {OfferDto, SupplierDto} from "./models/models";

function App() {

    const [mark, setMark] = React.useState<string>('');
    const [model, setModel] = React.useState<string>('');
    const [searchTerm, setSearchTerm] = React.useState<string>('');
    const [supplier, setSupplier] = React.useState<number | null>(null);
    const [offers, setOffers] = React.useState<OfferDto[]>([]);
    const [suppliers, setSuppliers] = React.useState<SupplierDto[]>([]);
    const [loading, setLoading] = React.useState(true);

    const debouncedSearchTerm = useDebounce(searchTerm, 500);

    useEffect(() => {
        fetchData()
    }, []);

    useEffect(() => {
        handleFilter(debouncedSearchTerm);
    }, [debouncedSearchTerm]);

    const fetchData = async () => {
        setLoading(true);
        try {
            const [offersData, suppliersData] = await Promise.all([
                getOffers(''),
                getPopularSuppliers()
            ]);
            setOffers(offersData);
            setSuppliers(suppliersData);
        } catch (err) {
            console.error("Failed to fetch data:", err);
        } finally {
            setLoading(false);
        }
    };

    const handleCreate = async () => {
        setLoading(true);
        await createOffer({mark: mark, model: model, supplierId: supplier!})
            .then(r => {
                setOffers(prevOffers => [...prevOffers, r]);
            }).then(() => {
                const item = suppliers.find(x => x.id == supplier!);
                item!.totalCount++;
            });
        setLoading(false)

        try {
            const newOffer = await createOffer({mark: mark, model: model, supplierId: supplier!})
            setOffers(prevOffers => [...prevOffers, newOffer]);

            setSuppliers(prev => prev.map(s =>
                s.id === supplier ? {...s, totalCount: s.totalCount + 1} : s
            ));

            setMark('');
            setModel('');
            setSupplier(null);
        } catch (err) {
            console.error("Failed to create offer:", err);
        } finally {
            setLoading(false);
        }
    };

    const handleFilter = async (searchTerm: string) => {
        setLoading(true);
        await getOffers(searchTerm)
            .then(offer => {
                setOffers(offer)
            });
        setLoading(false)
    };

    return (
        <div style={{margin:'20px'}}>

            {loading ? (
                <p>Loading...</p>
            ) : (
                <div>
                    <form onSubmit={handleCreate} className="offer-form">
                        <div className="form-group">
                            <label htmlFor="mark">Марка*</label>
                            <input
                                required
                                placeholder="Введите марку"
                                type="text"
                                value={mark}
                                onChange={(e) => setMark(e.target.value)}
                            />
                        </div>

                        <div className="form-group">
                            <label htmlFor="model">Модель*</label>
                            <input
                                required
                                placeholder="Введите модель"
                                type="text"
                                value={model}
                                onChange={(e) => setModel(e.target.value)}
                            />
                        </div>

                        <div className="form-group">
                            <label htmlFor="supplier">Поставщик*</label>
                            <select
                                required
                                id="supplier"
                                value={supplier || ''}
                                onChange={(e) => setSupplier(e.target.value ? Number(e.target.value) : null)}
                            >
                                <option value="">Выберите поставщика</option>
                                {suppliers.map(s => (
                                    <option key={s.id} value={s.id}>
                                        {s.name} (ID: {s.id})
                                    </option>
                                ))}
                            </select>
                        </div>

                        <button
                            type="submit"
                            className="submit-button"
                        >
                            Создать оффер
                        </button>
                    </form>


                    <div>
                        <input
                            type="text"
                            placeholder="Поиск по марке, модели или поставщику..."
                            value={searchTerm}
                            onChange={(e) => setSearchTerm(e.target.value)}
                        />
                        
                        <p>Offers</p>
                        <ul>
                            {offers.map(offer => (
                                <li key={offer.id}>
                                    {offer.mark} {offer.model}
                                </li>
                            ))}
                        </ul>
                    </div>

                    <div>
                        <p>Suppliers</p>
                        <ul>
                            {suppliers.map(supplier => (
                                <li key={supplier.id}>
                                    {supplier.name} {supplier.createdDate} {supplier.totalCount}
                                </li>
                            ))}
                        </ul>
                    </div>
                </div>
            )}
        </div>
    );
}

export default App;
