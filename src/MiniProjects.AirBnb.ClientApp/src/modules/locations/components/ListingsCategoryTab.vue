<template>

    <div class="fixed w-full top-0 pt-2 mt-20 z-10 flex items-center justify-center gap-4 content-padding theme-bg-primary">

        <!-- Previous button -->
        <previous-button class="mb-3 theme-bg-primary hover-shadow-zero"/>

        <!--Listings category container -->
        <listing-category-container :listingCategories="listingCategories as ListingCategory[]"/>

        <!-- Next button -->
        <next-button class="mb-3 theme-bg-primary hover-shadow-zero"/>

        <!-- Filters actions -->
        <div class="w-[500px] hidden lg:flex items-center justify-center pb-3">

            <!-- Locations filter -->
            <listings-filter :isMobile="false"/>

            <button class="ml-3 flex group h-12 w-auto px-4 theme-border justify-center items-center rounded-lg gap-3 theme-text-primary">
                <span class="text-xs font-medium whitespace-nowrap">Display total before taxes</span>
            </button>
        </div>

    </div>

</template>
<script setup lang="ts">
import PreviousButton from "@/common/components/PreviousButton.vue";
import NextButton from "@/common/components/NextButton.vue";
import ListingCategoryContainer from "@/modules/locations/components/ListingCategoryContainer.vue";
import ListingsFilter from "@/modules/locations/components/ListingsFilter.vue";
import { ListingCategory } from "@/modules/locations/models/ListingCategory";
import { onBeforeMount, ref } from "vue";
import { AirBnbApiClient } from "@/infrastructure/apiClients/airBnbApiClient/brokers/AirBnbApiClient";

const airBnbApiClient = new AirBnbApiClient();

const listingCategories = ref<Array<ListingCategory>>([]);

onBeforeMount(async () => {
    await loadListingCategories();
});

/*
    Loads listing categories
 */
const loadListingCategories = async () => {
    const response = await airBnbApiClient.listingCategories.getAsync()
    if (response.response) {
        listingCategories.value = response.response;
    }
};

</script>