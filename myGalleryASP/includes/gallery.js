// JavaScript Document
$(document).ready(function(){
	
	$('.gallery_thumbnails a').click(function(e){
	
		e.preventDefault();
		
		$('.gallery_thumbnails a').removeClass('selected');
		$('.gallery_thumbnails a').children().css('opacity','1');
		$(this).addClass('selected');
		$(this).children().css('opacity','0.4')
		
		var photo_caption = $(this).attr('title');
		var photo_fullsize = $(this).attr('href');
		var photo_preview = photo_fullsize.replace('.jpg','a.jpg')
		
		$('.gallery_caption').slideUp(500);
		$('.gallery_preview').fadeOut(500, function(){
			
			$('.gallery_preload_area').html('<img src="'+photo_preview+'"/>');
			$('.gallery_preload_area img').imgpreload(function(){
				
				$('.gallery_preview').html('<a class="overlaylink" href="'+photo_fullsize+'" title="'+photo_caption+'" style="background-image:url('+photo_preview+');"></a>');
				$('.gallery_caption').html('<p><a class="overlaylink zoom" href="'+photo_fullsize+'" title="'+photo_caption+'">View Larger</a></p><p>'+photo_caption+'</p>');
				$('.gallery_preview').fadeIn(500);
				$('.gallery_caption').slideDown(500);
				
				setFancyboxLinks();	
				updateThumbnails();
			});
		});
	});
	
	var first_photo_caption = $('.gallery_thumbnails a').first().attr('title');
	var first_photo_fullsize = $('.gallery_thumbnails a').first().attr('href');
	var first_photo_preview = first_photo_fullsize.replace('.jpg','a.jpg')
		
	$('.gallery_caption').slideUp(500);
	$('.gallery_preview').fadeOut(500, function(){
			
		$('.gallery_preload_area').html('<img src="'+first_photo_preview+'"/>');
		$('.gallery_preload_area img').imgpreload(function(){
				
			$('.gallery_preview').html('<a class="overlaylink" href="'+first_photo_fullsize+'" title="'+first_photo_caption+'" style="background-image:url('+first_photo_preview+');"></a>');
			$('.gallery_caption').html('<p><a class="overlaylink zoom" href="'+first_photo_fullsize+'" title="'+first_photo_caption+'">View Larger</a></p><p>'+first_photo_caption+'</p>');
			$('.gallery_preview').fadeIn(500);
			$('.gallery_caption').slideDown(500);
				
			setFancyboxLinks();	
			updateThumbnails();
		});
	});
});

function setFancyboxLinks(){
	$('a.overlaylink').fancybox({
		'titlePosition' : 'over',
		'overlayColor' : '#000',
		'overlayOpacity' : 0.8,
		'transitionOut' : 'elastic',
		'transitionIn' : 'elastic',
		'autoscale' : true		
	});
}

function updateThumbnails(){
	$('.gallery_thumbnails a').each(function(){
		if($('.gallery_preview a').attr('href') == $(this).attr('href') ){
			$(this).addClass('selected');
			$(this).children().fadeTo(250, .4);
		}
		else{
			$(this).removeClass('selected');
			$(this).children().css('opacity','1');
		}
	});
}