M = load ( 'speed_run.txt' );
n = M(:,1);
nsol=M(:,2);
ncounts=M(:,3);
tempo=M(:,4);

%Gráfico do tempo
plot(n,tempo,'-o')
figure
loglog(n,tempo,n,1.3.^(2*n)/(10.^6), 'r')
loglog(n,tempo,n,1.5.^n/(10.^6))

% Estimativa inferior para n=800:
t800 = 1.2.^(2*800)/(10.^6)/3600/24/365 


t800 = 1.5.^800/(10.^6)/3600/24/365  % em anos


plot(n,t)
loglog(n,t)
semilogy(n,t)
figure
plot(n,log10(t));


t_log=log10(t);

N=[n(20:end) 1+0*n(20:end)];
Coefs=pinv(N)*t_log(20:end);


hold on
Ntotal=[n n*0+1];

plot(n,10.^(Ntotal*Coefs),'r')
plot(n,Ntotal*Coefs,'r')

t800_log=[800 1]*Coefs
t800=10^t800_log / 3600/24/365

A2 = load("speed_run_weaksolution.txt");
n2=A2(:,1);
t2=A2(:,4);
semilogy(n,t,n2,t2)
A3=load("speed_run.txt");
hold on
semilogy(A3(:,1),A3(:,4),'k')
hold off  