<template>

    <div class="flex gap-6 md:gap-12 overflow-x-scroll no-scrollbar">

        <listing-category-card v-for="listingCategory in listingCategories" :listingCategory="listingCategory" :index="listingCategory.id"/>

    </div>

</template>
<script setup lang="ts">
import ListingCategoryCard from "@/modules/locations/components/ListingCategoryCard.vue";
import type { PropType } from "vue";
import type { ListingCategory } from "@/modules/locations/models/ListingCategory";

const props = defineProps({
    listingCategories: {
        type: Array as PropType<Array<ListingCategory>>,
        required: true
    }
});

</script>