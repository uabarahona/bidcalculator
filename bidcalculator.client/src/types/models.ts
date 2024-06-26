export enum CarType {
    Luxury = "Luxury",
    Common = "Common",
}

export type BidRequest = {
    bidAmount?: number,
    carType?: CarType
}

export type  CarBidFeeResponse  = {
    title: string,
    description: string, 
    fee: number
}

export type CarCostResponse = {
    carType: CarType,
    bidAmount: number,
    fees: CarBidFeeResponse[],
    totalCost: number
}
