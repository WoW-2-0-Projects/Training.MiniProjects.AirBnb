import type ApiClientBase from "@/infrastructure/apiClients/apiClientBase/ApiClientBase";
import { ListingCategory } from "@/modules/locations/models/ListingCategory";

export class ListingCategoriesEndpointsClients {
    private client: ApiClientBase;

    constructor(client: ApiClientBase) {
        this.client = client;
    }

    public async getAsync() {
        return await this.client.getAsync<Array<ListingCategory>>("api/listings/categories");
    }
}