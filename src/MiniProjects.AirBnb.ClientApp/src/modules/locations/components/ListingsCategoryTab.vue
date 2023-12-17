<template>

    <div class="fixed w-full top-0 pt-2 mt-20 z-10 flex items-center justify-center gap-4 content-padding theme-bg-primary">

        <horizontal-scroll :changeSource="listingCategories">
            <listing-category-card v-for="listingCategory in listingCategories"
                                   :listingCategory="listingCategory as ListingCategory"
                                   :index="listingCategory.id"/>
        </horizontal-scroll>

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
import ListingsFilter from "@/modules/locations/components/ListingsFilter.vue";
import { ListingCategory } from "@/modules/locations/models/ListingCategory";
import { onBeforeMount, ref } from "vue";
import { AirBnbApiClient } from "@/infrastructure/apiClients/airBnbApiClient/brokers/AirBnbApiClient";
import ListingCategoryCard from "@/modules/locations/components/ListingCategoryCard.vue";
import HorizontalScroll from "@/common/components/HorizontalScroll.vue";

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
        console.log('loaded')
        listingCategories.value = response.response;
    }
};

</script>