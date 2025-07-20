import axios from "axios";
import {CreateOfferDto, OfferDto, SupplierDto} from "./models/models";


const api = axios.create({
    baseURL: 'http://localhost:8080/api',
    headers: {
        'Content-Type': 'application/json',
    }
});

export const getOffers = (searchTerm: string): Promise<OfferDto[]> => api.get('/offer', {
    params: {
        searchTerm: searchTerm
    },
}).then(response => response.data);

export const getPopularSuppliers = (): Promise<SupplierDto[]> => api.get('/supplier').then(response => response.data);
export const createOffer = (offerData: CreateOfferDto): Promise<OfferDto> => api.post('/offer', offerData).then(response => response.data);