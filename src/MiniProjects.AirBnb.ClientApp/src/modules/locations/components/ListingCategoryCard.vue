<template>

    <div class="h-[80px] min-w-[50px] flex flex-col justify-center items-center cursor-pointer group main-transition">

        <!-- Category image -->
        <img class="h-[24px] w-[24px] mb-2 opacity-40 select-opacity primary-transition dark:invert"
             :src="listingCategory.imageUrl"
             :alt="`${listingCategory.name} image`"
        />

        <!-- Category name -->
        <h5 class="theme-text-primary opacity-40 text-xs font-medium select-opacity whitespace-nowrap primary-transition">{{listingCategory.name}}</h5>

        <!-- Category underline -->
        <div class="mt-[10px] w-4/5 h-[2px] opacity-0 theme-bg-accent select-opacity primary-transition"></div>
    </div>

</template>

<script setup lang="ts">

import type { ListingCategory } from "@/modules/locations/models/ListingCategory";

const props = defineProps({
    listingCategory: {
        type: Object as () => ListingCategory,
        required: true
    }
});

</script>