var tooltip=function(){
	var id = 'tt';
	var top = 3;
	var left = 3;
	var maxw = 600;
	var speed = 10;
	var timer = 20;
	var endalpha = 95;
	var alpha = 0;
	var tt,t,c,b,h;
	var ie = document.all ? true : false;
	// Modificaci�n (Ruben.Cobos)
	//		Se agreg� la variable MessageOrientation la cual controla la orientaci�n del ToolTip (Izquierda o Derecha), adem�s se incluy� un tercer
	//		par�metro en el constructor (sOrientation) el cual puede ser (Izq/Der) y determina la orientaci�n del ToolTip
	var MessageOrientation;
	return{
		show:function(v, sOrientation, w){
			// Pasar par�metro de Orientaci�n a la variable local
			MessageOrientation = sOrientation;
		
			// Flujo normal
			if(tt == null){
				tt = document.createElement('div');
				tt.setAttribute('id',id);
				t = document.createElement('div');
				t.setAttribute('id',id + 'top');
				c = document.createElement('div');
				c.setAttribute('id',id + 'cont');
				b = document.createElement('div');
				b.setAttribute('id',id + 'bot');
				tt.appendChild(t);
				tt.appendChild(c);
				tt.appendChild(b);
				document.body.appendChild(tt);
				tt.style.opacity = 0;
				tt.style.filter = 'alpha(opacity=0)';
				document.onmousemove = this.pos;
			}
			tt.style.display = 'block';
			c.innerHTML = v;
			tt.style.width = w ? w + 'px' : 'auto';
			if(!w && ie){
				t.style.display = 'none';
				b.style.display = 'none';
				tt.style.width = tt.offsetWidth;
				t.style.display = 'block';
				b.style.display = 'block';
			}
			if(tt.offsetWidth > maxw){tt.style.width = maxw + 'px'}
			h = parseInt(tt.offsetHeight) + top;
			clearInterval(tt.timer);
			tt.timer = setInterval(function(){tooltip.fade(1)},timer);
		},
		pos:function(e){
			var u = ie ? event.clientY + document.documentElement.scrollTop : e.pageY;
			var l = ie ? event.clientX + document.documentElement.scrollLeft : e.pageX;
			// Modificaci�n (Ruben.Cobos)
			//		Se modific� la secci�n de c�digo que situa el ToolTip, dependiendo del nuevo par�mtero agregado el ToolTip se desplegar� hacia (Izq/Der)
			//		originalmente se desplegaba el ToolTip hacia la derecha/arriba del puntero del Mouse.
			//
			//	L�neas originales
			//		tt.style.top = (u - h) + 'px';
			//		tt.style.left = (l + left) + 'px';
			//
			if(MessageOrientation == 'Der'){
				tt.style.top = (u + 20) + 'px';
				tt.style.left = (l + left) + 'px';
			}else{
				tt.style.top = (u + 20) + 'px';
				tt.style.left = (l - tt.offsetWidth) + 'px';
			}
			
		},
		fade:function(d){
			var a = alpha;
			if((a != endalpha && d == 1) || (a != 0 && d == -1)){
				var i = speed;
				if(endalpha - a < speed && d == 1){
					i = endalpha - a;
				}else if(alpha < speed && d == -1){
					i = a;
				}
				alpha = a + (i * d);
				tt.style.opacity = alpha * .01;
				tt.style.filter = 'alpha(opacity=' + alpha + ')';
			}else{
				clearInterval(tt.timer);
				if(d == -1){tt.style.display = 'none'}
			}
		},
		hide:function(){
			clearInterval(tt.timer);
			tt.timer = setInterval(function(){tooltip.fade(-1)},timer);
		}
	};
}();