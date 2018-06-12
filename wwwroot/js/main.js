(function ($) {
    "use strict";

    /*-------------------------
      main-menu active
    --------------------------*/
    $('.main-menu nav').meanmenu({
        meanScreenWidth: "991",
        meanMenuContainer: '.mobile-menu'
    });

    /*-------------------------
      search active
    --------------------------*/
    $(".icon-search").on("click", function () {
        $(this).parent().find('.toogle-content').slideToggle('medium');
    })


    /*-------------------------
      slider active
    --------------------------*/
    $('.slider-active').owlCarousel({
        loop: true,
        animateOut: 'fadeOut',
        animateIn: 'fadeIn',
        items: 1,
        dots: false,
        nav: true,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        responsive: {
            0: {
                items: 1
            },
            600: {
                items: 1
            },
            1000: {
                items: 1
            }
        }
    })

    /*-------------------------
      product thumb img slider
    --------------------------*/
    $('.pro-thumb-img-slider').owlCarousel({
        loop: true,
        animateOut: 'fadeOut',
        animateIn: 'fadeIn',
        items: 5,
        dots: false,
        margin: 25,
        nav: true,
        navText: ['<i class="fa fa-angle-left"></i>', '<i class="fa fa-angle-right"></i>'],
        responsive: {
            0: {
                items: 3
            },
            600: {
                items: 3
            },
            1000: {
                items: 5
            }
        }
    })

    /*-------------------------
      testimonial-active
    --------------------------*/

    $('.testimonial-active').owlCarousel({
        loop: true,
        animateOut: 'fadeOut',
        animateIn: 'fadeIn',
        items: 1,
        dots: false,
        nav: false,
        responsive: {
            0: {
                items: 1
            },
            600: {
                items: 1
            },
            1000: {
                items: 1
            }
        }
    })

    /*--- showlogin toggle function ----*/

    $('#showlogin').on('click', function () {
        $('#checkout-login').slideToggle(900);
    });

    /*--- showlogin toggle function ----*/
    $('#showcoupon').on('click', function () {
        $('#checkout_coupon').slideToggle(900);
    });

    /*--- showlogin toggle function ----*/
    $('#ship-box').on('click', function () {
        $('#ship-box-info').slideToggle(1000);
    });


    /*----------------------------
        youtube video
    ------------------------------ */
    $('.youtube-bg').YTPlayer({
        containment: '.youtube-bg',
        autoPlay: true,
        loop: true,
    });




    /* isotop active */

    $('.grid').imagesLoaded(function () {

        // init Isotope
        var $grid = $('.grid').isotope({
            itemSelector: '.grid-item',
            percentPosition: true,
            masonry: {
                // use outer width of grid-sizer for columnWidth
                columnWidth: '.grid-item',
            }
        });
    });











    /* counterUp */
    $('.count').counterUp({
        delay: 10,
        time: 1000
    });

    /*-------------------------------------------
        03. scrollUp jquery active
    --------------------------------------------- */
    $.scrollUp({
        scrollText: '<i class="fa fa-angle-up"></i>',
        easingType: 'linear',
        scrollSpeed: 900,
        animation: 'fade'
    });


    /*--
     Menu Sticky
    -----------------------------------*/
    var windows = $(window);
    var stickey = $(".style-6");

    windows.on('scroll', function () {
        var scroll = windows.scrollTop();
        if (scroll < 1) {
            stickey.removeClass("stick");
        } else {
            stickey.addClass("stick");
        }
    });




    /*-- Product Quantity --*/
    $('.product-quantity2').append('<span class="dec qtybtn"><i class="fa fa-angle-left"></i></span><span class="inc qtybtn"><i class="fa fa-angle-right"></i></span>');
    $('.qtybtn').on('click', function () {
        var $button = $(this);
        var oldValue = $button.parent().find('input').val();
        if ($button.hasClass('inc')) {
            var newVal = parseFloat(oldValue) + 1;
        } else {
            // Don't allow decrementing below zero
            if (oldValue > 0) {
                var newVal = parseFloat(oldValue) - 1;
            } else {
                newVal = 0;
            }
        }
        $button.parent().find('input').val(newVal);
    });




})(jQuery);

// Remove and add class color 
$(function () {
    $('.product-details .color-list a button').on('click', function () {
        $('a button').removeClass('active');
        $(this).addClass('active');
        console.log('Color Change');
    });

    // Share Links (Facebook)
    $('.share-icons #facebook').on('click', function () {
        var facebookShareUrl = 'https://www.facebook.com/sharer/sharer.php?u=';
        //catch the current url
        var url = window.location.href

        //var url = $(this).attr('href');
        if (url === "") {
            url = 'https://www.facebook.com/talesingold.finejewelry/';
        }

        url = encodeURI(url);
        $(this).attr('href', facebookShareUrl + url);
    });

    // Pin Link (Pinterest)
    $('.share-icons #pinterest').on('click', function () {
        var url = $(this).attr('href');

        if (url === "") {
            url = 'https://www.pinterest.com/talesingold/tales-in-gold-jewelry/';
        }

        $(this).attr('href', url);
    })

    // $('.menu li li li').on('click', function () {

    //     var firstElement = $(this).closest('li').text();
    //     var element2 = $(this).closest('li').parents('li').first().children('a').text();

    //     $('.breadcrumb-area ul').append('<li>'+element2+'</li>'+'<li>'+firstElement+'</li>');
        
    // })

    var text = $('#more-info p').text().replace(/__/g,'');
    $('#more-info p').empty();
    $('#more-info p').append(text);

});

// Lazy Loading  
$(function () {
    $('#lazy_main img').lazy();
});