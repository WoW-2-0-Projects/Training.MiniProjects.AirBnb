<template>

    <!-- Previous button -->
    <previous-button v-if="canScrollPrev" class="mb-3 theme-bg-primary hover-shadow-zero" @click="onPrevCategories"/>

    <div ref="scrollContainer" class="flex gap-6 md:gap-12 overflow-x-scroll no-scrollbar">
        <slot/>

<!--        <listing-category-card v-for="listingCategory in listingCategories" :listingCategory="listingCategory" :index="listingCategory.id"/>-->

    </div>

    <!-- Next button -->
    <next-button v-if="canScrollNext" class="mb-3 theme-bg-primary hover-shadow-zero" @click="onNextCategories"/>

</template>
<script setup lang="ts">
import { computed, nextTick, onMounted, onUnmounted, type PropType, ref, watch } from "vue";
import PreviousButton from "@/common/components/PreviousButton.vue";
import NextButton from "@/common/components/NextButton.vue";

const scrollContainer = ref<HTMLDivElement>();
const scrollDistance = 450

const props = defineProps({
    changeSource: {
        type: Array as PropType<Array<any>>,
        required: true
    }
});

/* region Watchers and Computed properties */

const scrollPosition = ref<number>(0);
const canScrollPrev = ref<boolean>(true);
const canScrollNext = ref<boolean>(true);

watch(() => [props.changeSource, scrollPosition.value], () => {

    nextTick(() => {
    //     console.log('next tick');

        if (scrollContainer.value) {
            canScrollPrev.value = scrollContainer.value.scrollLeft > 0
            canScrollNext.value = scrollContainer.value.scrollLeft + scrollContainer.value.clientWidth < scrollContainer.value.scrollWidth;
        }
    });
});

onMounted(() => {
    if (scrollContainer.value) {
        scrollContainer.value.addEventListener('scroll', (event: Event) => {
            const target = event.target as HTMLDivElement;
            scrollPosition.value = target.scrollLeft;
        })
    }
})

onUnmounted(() => {
    if (scrollContainer.value) {
        scrollContainer.value.removeEventListener('scroll', (event) => {
            const target = event.target as HTMLDivElement;
            scrollPosition.value = target.scrollLeft;
        })
    }
})

/* endregion */

/* region Methods */

const onPrevCategories = () => {
    if (scrollContainer.value) {
        scrollContainer.value.scroll({
            left: scrollContainer.value.scrollLeft - scrollDistance,
            behavior: "smooth"
        });
    }
}

const onNextCategories = () => {
    if (scrollContainer.value) {
        // scroll to right
        scrollContainer.value.scroll({
            left: scrollContainer.value?.scrollLeft + scrollDistance,
            behavior: "smooth"
        });
    }
}

/* endregion */

</script>