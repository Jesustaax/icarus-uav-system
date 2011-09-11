clear all
close all
filestr = strcat(date,'results.txt');

s = serial('COM4','BaudRate',115200,'Terminator','*');
fclose(s)
gpstime = 0;
gpslatitude = 0;
gpslongitude = 0;
rssi = 0;
latitude = 0;
longitude = 0;
startlat = 0;
startlon = 0;
i = 0;
data(1,:) = [0 0 0];
latvector = 0;
lonvector = 0;
latarray = 0;
lonarray = 0;
rssiarray = 0;
notbreak = 1;
delayvector = 0;
droppedpackets = 0;

suppresspackets = 1;
fopen(s);
fid = fopen(filestr, 'w');

while strcmp(s.status,'open')
        
        pause(.1) 
        fprintf(s,'A')
        
        tline = fscanf(s);
        if suppresspackets
            tline
        end
        
        c = clock;
        line = c(4:6);
        time = c(4) + c(5)/60 + c(6)/3600;
        
        if ~ischar(tline),   break,   end


        
        
        index = findstr('$',tline);
        if length(index) > 0
            i = i +1;
            if ~suppresspackets
                i
            end
            if length(index) > 1
                droppedpackets = droppedpackets + 1
            end
            
          tline = tline(index(length(index)):length(tline));
          
          fprintf(fid, tline);
          fprintf(fid,num2str(time));
          fprintf(fid,'\r');
          [token, remain] = strtok(tline,',');
          [gpstime, remain] = strtok(remain,',');
          [gpslatitude, remain] = strtok(remain,',');
          [gpslongitude, remain] = strtok(remain,',');
          [strrssi,remain] = strtok(remain,',');
          strrssi(length(strrssi)) = '.'; %Remove '*' Character at end.
          latitude = gps2num(gpslatitude);
          longitude = gps2num(gpslongitude);
          rssi = str2num(strrssi);
          if ~suppresspackets
            time
          end
          gtime = gps2time(gpstime)-5;
          if ~suppresspackets
            gtime
          end
          if ~suppresspackets
             disp('Delay:')
             disp(time-gtime)
          end
          delayvector(i) = time-gtime;
        


        end

        


    
end
fclose(s);
fclose(fid);