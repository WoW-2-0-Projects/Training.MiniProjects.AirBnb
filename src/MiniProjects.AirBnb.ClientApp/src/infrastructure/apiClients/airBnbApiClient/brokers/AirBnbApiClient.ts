import { ListingCategoriesEndpointsClients } from "@/infrastructure/apiClients/airBnbApiClient/brokers/ListingCategoriesEndpointsClients";
import ApiClientBase from "@/infrastructure/apiClients/apiClientBase/ApiClientBase";

export class AirBnbApiClient {
    private readonly client: ApiClientBase;
    public readonly baseUrl: string;

    constructor() {
        this.baseUrl = "https://localhost:7174";

        this.client = new ApiClientBase({
            baseURL: this.baseUrl
        });

        // this.locations = new LocationEndpointsClient(this.client);
        this.listingCategories = new ListingCategoriesEndpointsClients(this.client);
    }

    // public locations: LocationEndpointsClient;

    public listingCategories: ListingCategoriesEndpointsClients;
}