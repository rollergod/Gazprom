export interface SupplierDto {
    id: number;
    name: string;
    createdDate: string;
    totalCount: number;
}

export interface OfferDto {
    id: number;
    mark: string;
    model: string;
    supplierDto: SupplierDto;
}

export interface CreateOfferDto {
    mark: string;
    model: string;
    supplierId: number;
}

export interface OfferFilterParams {
    mark?: string;
    model?: string;
    supplierId?: number;
}