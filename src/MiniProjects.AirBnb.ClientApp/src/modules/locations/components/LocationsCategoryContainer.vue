<template>

    <div class="flex gap-6 md:gap-12 overflow-x-scroll no-scrollbar">

        <location-category-card v-for="location in 20"/>

    </div>

</template>
<script setup lang="ts">
import LocationCategoryCard from "@/modules/locations/components/LocationCategoryCard.vue";
</script>