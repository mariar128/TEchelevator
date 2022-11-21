<template>
  <div class="main">
      <h1>{{title}}</h1>
      <p>{{description}}</p>
      <div class="review">
          <h4>reviewer Name</h4>
          <div class="rating">
              <img src="../assets/star.png" class="ratingStar">
          </div>
          <h3>review Title</h3>
          <p>review content</p>
      </div>
  </div>
</template>
<script>
export default {
    name: 'product-review',
    methods: {
    },
    data() {
        return {
            title: 'Product Reviews for Cigar Parties For Dummies',
            description: 'Host and plan the perfect cigar party for all your squirrelly friends.',
            reviews: [
            {
                reviewer: 'Malcolm Madwell',
                title: 'What a book!',
                review:
                "It certainly is a book. I mean, I can see that. Pages kept together with glue and there's writing on it, in some language. Yes indeed, it is a book!",
                rating: 3
            },
            {
                reviewer: 'Tim Ferriss',
                title: 'Had a cigar party started in less than 4 hours.',
                review:
                "It should have been called the four hour cigar party. That's amazing. I have a new idea for muse because of this.",
                rating: 4
            },
            {
                reviewer: 'Ramit Sethi',
                title: 'What every new entrepreneurs needs. A door stop.',
                review:
                "When I sell my courses, I'm always telling people that if a book costs less than $20, they should just buy it. If they only learn one thing from it, it was worth it. Wish I learned something from this book.",
                rating: 1
            },
            {
                reviewer: 'Gary Vaynerchuk',
                title: 'And I thought I could write',
                review:
                "There are a lot of good, solid tips in this book. I don't want to ruin it, but prelighting all the cigars is worth the price of admission alone.",
                rating: 3
            }
            ]
        }
    },
computed: {
    averageRating() {
        let ratingSum = reviews.reduce((sum, nextReview)) => { return sum + nextReview.rating});
        let numberofReviews = reviews.length;
        return ratingSum / numberofReviews;
    } 
}







</script>
<style>
div.main div.well-display {
    display: flex;
    justify-content: space-around;
}
div.main div.well-display div.well {
    display: inline-block;
    width: 15%;
    border: 1px black solid;
    border-radius: 6px;
    text-align: center;
    margin: 0.25rem;
}
div.main div.well-display div.well span.amount {
    color: darkslategray;
    display: block;
    font-size: 2.5rem;
}
div.main div.review {
    border: 1px black solid;
    border-radius: 6px;
    padding: 1rem;
    margin: 10px;
}
div.main div.review div.rating {
    height: 2rem;
    display: inline-block;
    vertical-align: top;
    margin: 0 0.5rem;
}
div.main div.review div.rating img {
    height: 100%;
}
div.main div.review p {
    margin: 20px;
}
div.main div.review h3 {
    display: inline-block;
}
div.main div.review h4 {
    font-size: 1rem;
}
</style>